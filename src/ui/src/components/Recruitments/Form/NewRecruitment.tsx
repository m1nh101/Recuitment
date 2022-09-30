import { DatePicker, Form, Input, Modal, Select, Slider } from "antd"
import TextArea from "antd/lib/input/TextArea";

interface NewRecruitmnetModalProp{
  visible: boolean
}

const { RangePicker } = DatePicker

const initialFieldValue: {} = {
  ['salary']: [0, 20000000],
  ['experience']: [0, 15]
}

const NewRecruitment: React.FC<NewRecruitmnetModalProp> = ({...props}): JSX.Element => {
  return (
    <Modal
      open={props.visible}
      title="Tạo tuyển dụng mới"
      cancelText="Huỷ"
      okText="Tạo mới"
      bodyStyle={{overflowY: 'scroll', maxHeight: '70vh'}}
      width={1000}
      >
      <Form
        size="large"
        layout="vertical"
        initialValues={initialFieldValue}
      >
        <Form.Item
          name="name"
          label="Tiêu đề">
          <Input />
        </Form.Item>
        <Form.Item
          name="content"
          label="Nội dung">
          <TextArea rows={8} />
        </Form.Item>
        <Form.Item
          name="benifit"
          label="Quyền lợi">
          <TextArea rows={8} />
        </Form.Item>
        <Form.Item
          name="times"
          label="Thời hạn">
          <RangePicker style={{width: '100%'}}
            placeholder={["Bắt đầu", "Kết thúc"]}/>
        </Form.Item>
        <Form.Item
          name="salary"
          label="Lương">
          <Slider range min={0} max={200000000} value={[0, 20000000]}/>
        </Form.Item>
        <Form.Item
          name="experience"
          label="Kinh nghiệm">
          <Slider range min={0} max={100} value={[0, 10]}/>
        </Form.Item>
        <Form.Item
          name="quantity"
          label="Số lượng">
          <Input />
        </Form.Item>
        <Form.Item
          name="position"
          label="Vị trí">
          <Select style={{width: '100%'}}></Select>
        </Form.Item>
        <Form.Item
          name="department"
          label="Bộ phận">
          <Select style={{width: '100%'}}></Select>
        </Form.Item>
      </Form>
    </Modal>
  )
}

export default NewRecruitment;