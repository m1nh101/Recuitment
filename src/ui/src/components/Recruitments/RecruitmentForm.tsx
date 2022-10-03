import { Form, Input, Slider, Select, DatePicker, FormInstance } from "antd";
import { useForm } from "antd/es/form/Form";
import { Store } from "antd/lib/form/interface";
import TextArea from "antd/lib/input/TextArea";
import { useState, useEffect } from "react";
import { v4 } from "uuid";
import { DepartmentProp, getDepartments } from "../../apis/department";
import { PositionProps, getPositions } from "../../apis/position";

export interface RecruitmentFormProp{
  initialValues: Store | undefined
  onFinish: (value: any) => void
  form: FormInstance
}

const { Option } = Select

const { RangePicker } = DatePicker

const RecruitmentForm: React.FC<RecruitmentFormProp> = ({...props}): JSX.Element => {
  const [departments, setDepartments] = useState<Array<DepartmentProp>>([])
  const [positions, setPositions] = useState<Array<PositionProps>>([])

  useEffect(() => {
    getDepartments().then(res => setDepartments(res.data ?? []))
    getPositions().then(res => setPositions(res.data ?? []))
  }, [])

  return (
    <Form
      size="large"
      layout="vertical"
      initialValues={props.initialValues}
      form={props.form}
      onFinish={props.onFinish}
    >
      <Form.Item
        name="name"
        label="Tiêu đề"
        rules={[{
          required: true,
          message: "Trường này là bắt buộc"
        }]}>
        <Input />
      </Form.Item>
      <Form.Item
        name="content"
        label="Nội dung"
        rules={[{
          required: true,
          message: "Trường này là bắt buộc"
        }]}>
        <TextArea rows={8} />
      </Form.Item>
      <Form.Item
        name="benifit"
        label="Quyền lợi"
        rules={[{
          required: true,
          message: "Trường này là bắt buộc"
        }]}>
        <TextArea rows={8} />
      </Form.Item>
      <Form.Item
        name="times"
        label="Thời hạn"
        rules={[{
          required: true,
          message: "Trường này là bắt buộc"
        }]}>
        <RangePicker style={{ width: '100%' }}
          placeholder={["Bắt đầu", "Kết thúc"]} />
      </Form.Item>
      <Form.Item
        name="salary"
        label="Lương">
        <Slider range min={0} max={200000000} value={[0, 20000000]} />
      </Form.Item>
      <Form.Item
        name="experience"
        label="Kinh nghiệm">
        <Slider range min={0} max={100} value={[0, 10]} />
      </Form.Item>
      <Form.Item
        name="quantity"
        label="Số lượng"
        rules={[{
          required: true,
          message: "Trường này là bắt buộc"
        }]}>
        <Input type="number" name="quantity" />
      </Form.Item>
      <Form.Item
        name="position"
        label="Vị trí"
        rules={[{
          required: true,
          message: "Trường này là bắt buộc"
        }]}>
        <Select style={{ width: '100%' }}>
          {
            positions.map(item => <Option key={v4()} value={item.id}>{item.name}</Option>)
          }
        </Select>
      </Form.Item>
      <Form.Item
        name="department"
        label="Bộ phận"
        rules={[{
          required: true,
          message: "Trường này là bắt buộc"
        }]}>
        <Select style={{ width: '100%' }}>
          {
            departments.map(item => <Option key={v4()} value={item.id}>{item.name}</Option>)
          }
        </Select>
      </Form.Item>
    </Form>
  )
}

export default RecruitmentForm;