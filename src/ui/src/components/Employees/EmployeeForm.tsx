import { Form, Select } from "antd"
import { FormInstance } from "antd/es/form/Form"
import { Input } from "antd"

interface FormProps {
  form: FormInstance
  onFinish: () => void
}

const EmployeeForm: React.FC<FormProps> = ({ ...props }): JSX.Element => {
  return <Form
    form={props.form}
    onFinish={props.onFinish}
    layout="vertical"
    size="large"
    >
    <Form.Item
      label="Họ tên"
      name="name">
      <Input />
    </Form.Item>
    <Form.Item
      label="Tên đăng nhập"
      name="username">
      <Input />
    </Form.Item>
    <Form.Item
      label="Email"
      name="email">
      <Input />
    </Form.Item>
    <Form.Item
      label="Mật khẩu"
      name="password">
      <Input.Password />
    </Form.Item>
    <Form.Item
      label="Phòng ban"
      name="department">
      <Select>

      </Select>
    </Form.Item>
    <Form.Item
      label="Vị trí"
      name="position">
      <Select>
        
      </Select>
    </Form.Item>
    <Form.Item
      label="Cấp bậc"
      name="level">
      <Select>
        
      </Select>
    </Form.Item>
    <Form.Item
      label="Quyền"
      name="role">
      <Select>
        
      </Select>
    </Form.Item>
  </Form>
}

export default EmployeeForm