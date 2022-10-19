import { Table } from "antd"
import { ColumnsType } from "antd/lib/table"
import { useSelector } from "react-redux"
import { EmployeeViewProps } from "../../helpers/employee"
import { getEmployees } from "../../store/employeeSlice"

const ListEmployee: React.FC = (): JSX.Element => {
  const columns: ColumnsType<EmployeeViewProps> = [
    {
      title: 'Họ và Tên',
      dataIndex: 'name',
      key: 'name'
    },
    {
      title: 'Phòng ban',
      dataIndex: 'department',
      key: 'department'
    },
    {
      title: 'Vị trí',
      dataIndex: 'position',
      key: 'position'
    },
    {
      title: 'Cấp bậc',
      dataIndex: 'level',
      key: 'level'
    },
    {
      title: 'Quyền',
      dataIndex: 'role',
      key: 'role'
    }
  ]

  const employees = useSelector(getEmployees)

  return <Table columns={columns} dataSource={employees}></Table>
}

export default ListEmployee