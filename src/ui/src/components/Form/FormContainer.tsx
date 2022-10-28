import { Col, Collapse, Modal, Row, Space, Tag } from "antd"
import { useForm } from "antd/lib/form/Form"
import ApplicationForm from "./ApplicationForm"
import BookingForm from "./BookingForm"
import InterviewForm from "./InterviewForm"

interface FormContainerProps {
  visible: boolean
  changeVisible: (visible: boolean) => void
}

const { Panel } = Collapse

const FormContainer: React.FC<FormContainerProps> = ({ ...props }): JSX.Element => {
  const [applicationForm] = useForm()
  const [bookingForm] = useForm()
  const [resultForm] = useForm()

  return (
    <Modal
      open={props.visible}
      title="Chi tiết thông tin"
      okText="Lưu"
      cancelText="Huỷ"
      bodyStyle={{ overflowY: 'scroll', maxHeight: '70vh' }}
      width={1500}
      onCancel={() => props.changeVisible(false)}>
      <Row gutter={[16, 16]}>
        <Col span={8}>
          <Space direction="vertical" style={{width: '100%'}}>
          <Collapse collapsible="header" activeKey={["adkfjkadfhkad"]}>
          <Panel showArrow={false} key="adkfjkadfhkad" header={<Tag style={{fontSize: '18px'}} color="#2db7f5">Thông tin ứng viên</Tag>}>
            <ApplicationForm onFinish={function (value: any): void {
              throw new Error("Function not implemented.")
            }} form={applicationForm} />
          </Panel>
        </Collapse>
        <Collapse>
        <Panel showArrow={false} key="lahfkajhdkjf" header={<Tag style={{fontSize: '18px'}} color="#2db7f5">Thông tin lịch phỏng vấn</Tag>}>
            <BookingForm onFinish={function (value: any): void {
              throw new Error("Function not implemented.")
            }} form={bookingForm} />0
          </Panel>
        </Collapse>
          </Space>
        </Col>
        <Col span={16}>
        <Collapse>
          <Panel showArrow={false} header={<Tag style={{fontSize: '18px'}} color="red">Đánh giá ứng viên</Tag>} key="129387kajdfj">
            <InterviewForm />
          </Panel>
        </Collapse>
        </Col>
      </Row>
    </Modal>
  )
}

export default FormContainer