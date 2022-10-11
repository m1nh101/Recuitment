import { DatePicker, Form, Select } from "antd"
import { FormInstance } from "antd/es/form/Form"

interface BookingFormProps {
  onFinish: (value: any) => void
  form: FormInstance
}

const { RangePicker } = DatePicker

const BookingForm: React.FC<BookingFormProps> = ({...props}): JSX.Element => {
  return (
    <Form
      size="large"
      layout="vertical"
      form={props.form}
      onFinish={props.onFinish}
      >
        <Form.Item
          label="Ngày"
          name="date">
          <DatePicker style={{width: '100%'}}/>
        </Form.Item>
        <Form.Item
          label="Thời gian"
          name="time">
            <RangePicker placeholder={["Bắt đầu", "Kết thúc"]} picker="time" style={{width: '100%'}}/>
        </Form.Item>
        <Form.Item
          label="Người phỏng vấn chuyên môn"
          name="reviewer">
          <Select>

          </Select>
        </Form.Item>
    </Form>
  )
}

export default BookingForm