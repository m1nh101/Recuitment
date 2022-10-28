import { Form, Input, Select, Slider } from "antd"
import TextArea from "antd/lib/input/TextArea";

const { Item } = Form
const { Option } = Select

const InterviewForm: React.FC = (): JSX.Element => {
  return (
    <Form layout="vertical">
      <Item
        label="Tính cách"
        name="attitude">
          <TextArea rows={4}/>
      </Item>
      <Item
        label="Kinh nghiệm"
        name="experience">
        <TextArea rows={4}/>
      </Item>
      <Item
        label="Kỹ năng chuyên môn"
        name="skill">
        <TextArea rows={4} />
      </Item>
      <Item
        label="Khả năng giải quyết vấn đề"
        name="resolveProblem">
        <TextArea rows={4} />
      </Item>
      <Item
        label="Khả năng học hỏi"
        name="selfLearning">
        <TextArea rows={4} />
      </Item>
      <Item
        label="Mong muốn"
        name="desire">
        <TextArea rows={4}/>
      </Item>
      <Item
        label="Mức lương mong muốn"
        name="salary">
          <Slider range min={0} max={200000000} value={[0, 20000000]} />
      </Item>
      <Item
        label="Trình độ"
        name="level">
          <Select>

          </Select>
      </Item>
      <Item
        label="Ghi chú"
        name="note">
          <TextArea rows={4}/>
        </Item>
      <Item
        label="Đánh giá"
        name="result">
          <Select>
            <Option value="8">Đạt</Option>
            <Option value="9">Trượt</Option>
          </Select>
      </Item>
    </Form>
  )
}

export default InterviewForm;