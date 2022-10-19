import { Modal } from "antd"
import { useForm } from "antd/es/form/Form"
import client from "../../apis/client"
import BookingForm from "./BookingForm"

interface BookingModalProps {
  visible: boolean
  changeVisible: (state: boolean) => void
  candidate: number
}

const NewBookingModal: React.FC<BookingModalProps> = ({...props}): JSX.Element => {

  const [form] = useForm()

  const submitForm = (value: any) => {
    const payload = {
      applicationId: props.candidate,
      date: value.date,
      start: value.time[0],
      end: value.time[1],
      reviewerId: value.reviewer
    }

    client.post('/bookings', payload)
      .then(res => {
        if(res.data.statusCode === 200){
          alert("hello")
        }
      })

    console.log(payload)
  }

  return (
    <Modal 
      open={props.visible}
      onCancel={() => props.changeVisible(false)}
      cancelText="Huỷ"
      okText="Tạo"
      title="Đặt lịch phỏng vấn"
      onOk={form.submit}>
      <BookingForm onFinish={submitForm} form={form} />
    </Modal>
  )
}

export default NewBookingModal;