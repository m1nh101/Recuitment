import { ExclamationCircleOutlined } from "@ant-design/icons"
import { Button, Modal, Space, Table } from "antd"
import { ColumnsType } from "antd/lib/table"
import React from "react"
import { useState } from "react"
import { Link } from "react-router-dom"
import { deleteCandidateFromRecruitment } from "../../apis/candidate"
import { CandidateViewProp } from "../../helpers/candidates"
import NewBookingModal from "../Bookings/NewBookingModal"
import UpdateCandidateModal from "./UpdateCandidateModal"

interface ListCandidateProps {
  source: Array<CandidateViewProp>,
  recruitment?: string
}

const { confirm } = Modal

const ListCandidate: React.FC<ListCandidateProps> = ({...props}): JSX.Element => {
  const [selectCandidate, setSelectCandidate] = useState<number>(0)
  
  const [visible, setVisible] = useState<boolean>(false)
  const [bookingVisible, setBookingVisible] = useState<boolean>(false)

  const columns: ColumnsType<CandidateViewProp> = [
    {
      title: 'Họ và Tên',
      dataIndex: 'name',
      key: 'name',
      render: (_, data: CandidateViewProp) => {
        return <Link to="">{data.name}</Link>
      }
    },
    {
      title: 'Giới tính',
      dataIndex: 'gender',
      key: 'gender'
    },
    {
      title: 'Ngày sinh',
      dataIndex: 'birthday',
      key: 'birthday'
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
      title: '',
      dataIndex: '',
      key: 'action',
      render: (_, data: CandidateViewProp) => {
        return (<Space>
          <Button type="primary" onClick={() => setBookingVisible(true)}>Tạo lịch phỏng vấn</Button>
          <Button type="primary" onClick={() => {setSelectCandidate(data.id); setVisible(true)}}>Chỉnh sửa</Button>
          <Button onClick={() => showConfirm(data.id)} type="primary" danger>Xoá</Button>
        </Space>)
      }
    }
  ]

  const showConfirm = (id: number) => {
    confirm({
      title: 'Bạn có chắc muốn xoá ứng viên khỏi đơn tuyển dụng này?',
      icon: <ExclamationCircleOutlined />,
      onOk() {
        deleteCandidateFromRecruitment(props.recruitment!, id.toString())
      }
    });
  };

  return (
    <>
      <Table bordered={true} dataSource={props.source} columns={columns}></Table>
      
      <UpdateCandidateModal
        visible={visible}
        changeVisible={setVisible}
        recruitmentId={parseInt(props.recruitment!)}
        candidateId={selectCandidate} />

      <NewBookingModal
        visible={bookingVisible}
        changeVisible={setBookingVisible}
        recruitmentId={parseInt(props.recruitment!)}
        candidate={selectCandidate} />
    </>
  )
}

export default ListCandidate