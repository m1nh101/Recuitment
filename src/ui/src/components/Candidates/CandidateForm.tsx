import { InboxOutlined } from "@ant-design/icons"
import { DatePicker, Form, Input, Radio } from "antd"
import { FormInstance } from "antd/es/form/Form"
import locale from "antd/lib/date-picker/locale/vi_VN"
import TextArea from "antd/lib/input/TextArea"
import Dragger from "antd/lib/upload/Dragger"
import { Moment } from "moment"

export interface CandidateFormProp{
  size?: string
  onFinish: (value: any) => void
  form: FormInstance
}

export interface CandidateFormValue {
  name: string
  gender: string
  address: string
  birthday: Moment
  attachment: FileList
  email: string
  phone: string
  note: string
  qualification: string
}

const CandidateForm: React.FC<CandidateFormProp> = ({...props}): JSX.Element => {
  return (
    <Form 
      layout="vertical"
      size="large"
      form={props.form}
      onFinish={props.onFinish}>
        <Form.Item
          name="name"
          label="Họ và tên"
          rules={[{
            required: true,
            message: 'Trường này là bắt buộc'
          },
          {
            pattern: /^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s\W|_]+$/,
            message: 'Tên không đúng định dạng'
          }]}>
          <Input />
        </Form.Item>
        <Form.Item
          name="gender"
          label="Giới tính"
          rules={[{
            required: true,
            message: 'Trường này là bắt buộc'
          }]}>
          <Radio.Group
            value={props.form.getFieldValue('gender')}
            onChange={(event) => props.form.setFieldValue('gender', event.target.value)}>
            <Radio value="0">Nam</Radio>
            <Radio value="1">Nữ</Radio>
          </Radio.Group>
        </Form.Item>
        <Form.Item
          name="birthday"
          label="Ngày sinh"
          rules={[{
            required: true,
            message: 'Trường này là bắt buộc'
          }]}>
          <DatePicker locale={locale} placeholder="Chọn" style={{width: '100%'}}/>
        </Form.Item>
        <Form.Item
          name="email"
          label="Email"
          rules={[{
            required: true,
            message: 'Trường này là bắt buộc'
          }, {
            pattern: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g,
            message: 'Email không hợp lệ'
          }]}>
          <Input />
        </Form.Item>
        <Form.Item
          name="phone"
          label="Số điện thoại"
          rules={[{
            required: true,
            message: 'Trường này là bắt buộc'
          }, {
            pattern: /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/,
            message: 'Số điện thoại không hợp lệ'
          }]}>
          <Input />
        </Form.Item>
        <Form.Item
          name="address"
          label="Địa chỉ"
          rules={[{
            required: true,
            message: 'Trường này là bắt buộc'
          }]}>
          <Input />
        </Form.Item>
        <Form.Item
          name="qualification"
          label="Bằng cấp"
          rules={[{
            required: true,
            message: 'Trường này là bắt buộc'
          }]}>
          <Input />
        </Form.Item>
        <Form.Item
          label="File đính kèm(CV)"
          name="attachment"
          valuePropName="fileList"
          getValueFromEvent={(e) => {
            if(Array.isArray(e)){
              return e
            }

            return e?.fileList
          }}
          rules={[{
            required: false,
            message: 'Bạn cần upload file đính kèm'
          }]}>
          <Dragger multiple accept="application/pdf" beforeUpload={(file, files) => false}>
          <p className="ant-upload-drag-icon">
            <InboxOutlined />
          </p>
          <p className="ant-upload-text">Kéo thả file vào đây</p>
          <p className="ant-upload-hint">
            Chỉ chấp nhận file pdf
          </p>
          </Dragger>
        </Form.Item>
        <Form.Item
          name="note"
          label="Ghi chú"
          >
          <TextArea rows={4}/>
        </Form.Item>
    </Form>
  )
}

export default CandidateForm;