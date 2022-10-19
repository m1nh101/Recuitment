import { Form, Select } from "antd"
import { FormInstance } from "antd/es/form/Form"
import { Input } from "antd"
import { useSelector } from "react-redux"
import { getDepartments, getLevel, getPositions, getRoles } from "../../store/utilSlice"
import { v4 } from "uuid"

const { Option } = Select

interface FormProps {
  form: FormInstance
  onFinish: (value: EmployeeFormProps) => void
}

export interface EmployeeFormProps {
  name: string
  username: string
  password: string
  email: string
  departmentId : number
  role: string
  levelId: number
  positionId: number
}

const EmployeeForm: React.FC<FormProps> = ({ ...props }): JSX.Element => {
  const department = useSelector(getDepartments)
  const levels = useSelector(getLevel)
  const positions = useSelector(getPositions)
  const roles = useSelector(getRoles)

  return <Form
    form={props.form}
    onFinish={props.onFinish}
    layout="vertical"
    size="large"
    >
    <Form.Item
      label="Họ tên"
      name="name"
      rules={[{
        'required': true,
        'message': 'Trường này là bắt buộc'
      },
      {
        'pattern': /^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s\W|_]+$/,
        'message': 'Tên chưa đúng định dạng'
      }]}>
      <Input />
    </Form.Item>
    <Form.Item
      label="Tên đăng nhập"
      name="username"
      rules={[{
        'required': true,
        'message': 'Trường này là bắt buộc'
      }]}>
      <Input />
    </Form.Item>
    <Form.Item
      label="Email"
      name="email"
      rules={[
        {
          'required': true,
          'message': 'Chưa nhập email'
        },
        {
          'pattern': /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g,
          'message': 'Email chưa đúng định dạng'
        }
      ]}>
      <Input />
    </Form.Item>
    <Form.Item
      label="Mật khẩu"
      name="password"
      rules={[{
        'required': true,
        'message': 'Chưa nhập mật khẩu'
      },
      {
        'pattern': /^(?=.*\d)(?=.*[a-z])[0-9a-zA-Z]{6,}$/,
        'message': 'Mật khẩu chưa đủ mạnh'
      }]}>
      <Input.Password />
    </Form.Item>
    <Form.Item
      label="Phòng ban"
      name="departmentId"
      rules={[
        {
          'required': true,
          'message': 'Chưa chọn phòng ban'
        }
      ]}>
      <Select>
        {
          department.map(item => <Option key={v4()} value={item.id}>{item.name}</Option>)
        }
      </Select>
    </Form.Item>
    <Form.Item
      label="Vị trí"
      name="positionId"
      rules={[
        {
          'required': true,
          'message': 'Chưa chọn vi trí'
        }
      ]}>
      <Select>
        {
          positions.map(item => <Option key={v4()} value={item.id}>{item.name}</Option>)
        }
      </Select>
    </Form.Item>
    <Form.Item
      label="Cấp bậc"
      name="levelId"
      rules={[
        {
          'required': true,
          'message': 'Chưa chọn cấp bậc'
        }
      ]}>
      <Select>
        {
          levels.map(item => <Option key={v4()} value={item.id}>{item.name}</Option>)
        }
      </Select>
    </Form.Item>
    <Form.Item
      label="Quyền"
      name="role"
      rules={[
        {
          'required': true,
          'message': 'Chưa chọn quyền'
        }
      ]}>
      <Select>
        {
          roles.map(item => <Option key={v4()} value={item.id}>{item.name}</Option>)
        }
      </Select>
    </Form.Item>
  </Form>
}

export default EmployeeForm