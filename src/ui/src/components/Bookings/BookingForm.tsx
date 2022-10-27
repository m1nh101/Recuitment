import { Col, DatePicker, Form, Row, Select, Tag } from "antd"
import { FormInstance } from "antd/es/form/Form"
import { Moment } from "moment"
import { useEffect, useState } from "react"
import { v4 } from "uuid"
import { getReviewer, ListReviewerProps } from "../../apis/employee"

interface BookingFormProps {
  onFinish: (value: any) => void
  form: FormInstance
}

export interface BookingFormFieldProps {
  date: Moment
  time: [Moment, Moment]
  reviewer: string
}

const { RangePicker } = DatePicker
const { Option } = Select

const BookingForm: React.FC<BookingFormProps> = ({...props}): JSX.Element => {

  const [reviewers, setReviewers] = useState<Array<ListReviewerProps>>([])

  useEffect(() => {
    getReviewer()
      .then(res => {
        if(res.statusCode === 200){
          setReviewers(res.data!)
        }
      })
  }, [])

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
          <DatePicker style={{width: '100%'}} placeholder="Ngày phỏng vấn"/>
        </Form.Item>
        <Form.Item
          label="Thời gian"
          name="time">
            <RangePicker placeholder={["Bắt đầu", "Kết thúc"]} format="HH:mm" picker="time" style={{width: '100%'}}/>
        </Form.Item>
        <Form.Item
          label="Người phỏng vấn chuyên môn"
          name="reviewer">
          <Select>
            {
              reviewers.map(item => <Option key={v4()} value={item.id}>
                <Row justify="space-between">
                  <Col span={12}>{item.name}</Col>
                  <Col span={4}>
                    <Tag color="red">{item.department}</Tag>
                  </Col>
                </Row>
              </Option>)
            }
          </Select>
        </Form.Item>
    </Form>
  )
}

export default BookingForm