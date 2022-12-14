import { ExclamationCircleOutlined } from "@ant-design/icons"
import { Button, Modal, Space, Table } from "antd"
import { ColumnsType } from "antd/lib/table"
import moment from "moment"
import React from "react"
import { useState } from "react"
import { useSelector } from "react-redux"
import { Link } from "react-router-dom"
import { v4 } from "uuid"
import { ApplicationInRecruitmentProps, deleteApplicationFromRecruitment, Status } from "../../apis/application"
import { cancelBooking } from "../../apis/booking"
import { getCurrentRecruitment } from "../../store/recruitmentSlice"
import NewBookingModal from "../Bookings/NewBookingModal"
import UpdateCandidateModal from "./UpdateApplicationModal"

interface ListCandidateProps {
  source: Array<ApplicationInRecruitmentProps>,
  remove: (id: number) => void
  update: (id: number, status: Status) => void
}

const { confirm } = Modal

const ListCandidate: React.FC<ListCandidateProps> = ({...props}): JSX.Element => {
  const [selectCandidate, setSelectCandidate] = useState<number>(0)
  
  const [visible, setVisible] = useState<boolean>(false)
  const [bookingVisible, setBookingVisible] = useState<boolean>(false)
  const currentRecruitment: number = useSelector(getCurrentRecruitment)

  const actionRender = (data: ApplicationInRecruitmentProps): JSX.Element => {
    return (
      <Space key={v4()}>
        {
          data.status === Status.BookedInterview && <Button type="primary">Chi tiết</Button>
        }
        {
          data.status === Status.WaitBookingInterview && <Button type="primary" onClick={() => {setSelectCandidate(data.id!); setBookingVisible(true)}}>Tạo lịch phỏng vấn</Button>
        }
        {
          data.status === Status.WaitBookingInterview && <Button type="primary" onClick={() => {setSelectCandidate(data.id!); setVisible(true)}}>Chỉnh sửa</Button>
        }
        {
          data.status === Status.WaitBookingInterview && <Button type="primary" danger onClick={() => {setSelectCandidate(data.id!); showConfirm(data.id!)}}>Xoá</Button>
        }
        {
          data.status === Status.BookedInterview && <Button type="primary" onClick={() => {setSelectCandidate(data.id!); showCancelBookingConfirm(data.id!)}} danger>Huỷ</Button>
        }
      </Space>
    )
  }

  const columns: ColumnsType<ApplicationInRecruitmentProps> = [
    {
      title: 'Họ và Tên',
      dataIndex: 'name',
      key: 'name',
      render: (_, data: ApplicationInRecruitmentProps) => {
        return <Link to="">{data.name}</Link>
      }
    },
    {
      title: 'Giới tính',
      dataIndex: 'gender',
      key: 'gender',
      render: (value: number) => <p>{value == 0 ? "Nam": "Nữ"}</p>
    },
    {
      title: 'Ngày sinh',
      dataIndex: 'birthday',
      key: 'birthday',
      render: (value: string) => <p>{moment(value).format("DD/MM/YYYY")}</p>
    },
    {
      title: 'Email',
      dataIndex: 'email',
      key: 'email'
    },
    {
      title: 'Điện thoại',
      dataIndex: 'phone',
      key: 'phone'
    },
    {
      title: 'Địa chỉ',
      dataIndex: 'address',
      key: 'address'
    },
    {
      title: 'Hành động',
      dataIndex: '',
      key: 'action',
      render: (_, data: ApplicationInRecruitmentProps) => actionRender(data)
    }
  ]

  const showConfirm = (id: number) => {
    confirm({
      title: 'Bạn có chắc muốn xoá ứng viên khỏi đơn tuyển dụng này?',
      icon: <ExclamationCircleOutlined />,
      onOk() {
        deleteApplicationFromRecruitment(currentRecruitment, id)
          .then(res => {
          if(res){
            props.remove(id)
          }
        })
      }
    });
  };

  const showCancelBookingConfirm = (id: number) => {
    confirm({
      title: 'Bancó chắc muốn huỷ?',
      icon: <ExclamationCircleOutlined />,
      onOk() {
        cancelBooking(id).then(res => {
          if(res){
            props.update(id, Status.WaitBookingInterview)
          }
        })
      }
    })
  }

  return (
    <>
      <Table bordered={true} dataSource={props.source} columns={columns}></Table>
      
      <UpdateCandidateModal
        visible={visible}
        changeVisible={setVisible}
        recruitmentId={currentRecruitment}
        application={selectCandidate} />

      <NewBookingModal
        visible={bookingVisible}
        changeVisible={setBookingVisible}
        candidate={selectCandidate} />
    </>
  )
}

export default ListCandidate