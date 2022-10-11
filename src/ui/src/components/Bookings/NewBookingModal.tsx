import { Modal } from "antd"
import { useForm } from "antd/es/form/Form"
import BookingForm from "./BookingForm"

interface BookingModalProps {
  visible: boolean
  changeVisible: (state: boolean) => void
  recruitmentId: number
  candidate: number
}

const NewBookingModal: React.FC<BookingModalProps> = ({...props}): JSX.Element => {

  const [form] = useForm()

  return (
    <Modal 
      open={props.visible}
      onCancel={() => props.changeVisible(false)}
      cancelText="Huỷ"
      okText="Tạo"
      title="Đặt lịch phỏng vấn">
      <BookingForm onFinish={function (value: any): void {
        throw new Error("Function not implemented.")
      } } form={form} />
    </Modal>
  )
}

export default NewBookingModal;