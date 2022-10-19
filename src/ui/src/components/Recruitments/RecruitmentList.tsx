import Table, { ColumnsType } from "antd/lib/table"
import { useDispatch, useSelector } from "react-redux"
import { Link } from "react-router-dom"
import { getRecruitmentDetail } from "../../apis/recruitment"
import { RecruitmentViewProps } from "../../helpers/recruitment"
import { recruitmentSelector, selectRecruitment } from "../../store/recruitmentSlice"
import { AppDispatch } from "../../store/store"

const RecruitmentList: React.FC = (): JSX.Element => {

  const dispatch = useDispatch<AppDispatch>()
  const recruitments = useSelector(recruitmentSelector)

  const selectRecruitmentHandler = (id: number) => {
    getRecruitmentDetail(id ?? 0).then(res => {
      if (res.statusCode === 200){
        dispatch(selectRecruitment(id));
      }
    })
  }
  
  const columns: ColumnsType<RecruitmentViewProps> = [
    {
      title: 'Tiêu đề',
      dataIndex: 'name',
      key: 'name',
      render: (_, data: RecruitmentViewProps) => {
        return <Link
          onClick={() => selectRecruitmentHandler(data.id)}
          to={`recruitments/${data.id}`}>{data.name}</Link>
      }
    },
    {
      title: 'Ngày bắt đầu',
      dataIndex: 'startDate',
      key: 'startDate'
    },
    {
      title: 'Ngày kết thúc',
      dataIndex: 'endDate',
      key: 'endDate',
    },
    {
      title: 'Khoảng lương',
      dataIndex: 'salary',
      key: 'salary'
    },
    {
      title: 'Kinh nghiệm',
      dataIndex: 'experience',
      key: 'experience'
    },
    {
      title: 'Số lượng',
      dataIndex: 'number',
      key: 'number'
    },
    // {
    //   title: '',
    //   dataIndex: '',
    //   key: 'action',
    //   render: (_, data: RecruitmentViewProps) => {
    //     return <Button type="primary">Chỉnh sửa</Button>
    //   }
    // }
  ]
  
  return (
    <Table columns={columns} dataSource={recruitments}></Table>
  )
}

export default RecruitmentList;