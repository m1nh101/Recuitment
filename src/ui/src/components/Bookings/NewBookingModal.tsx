import { Modal } from "antd"
import { useForm } from "antd/es/form/Form"
import moment from "moment"
import { postBooking } from "../../apis/booking"
import BookingForm, { BookingFormFieldProps } from "./BookingForm"

interface BookingModalProps {
  visible: boolean
  changeVisible: (state: boolean) => void
  candidate: number
}

const NewBookingModal: React.FC<BookingModalProps> = ({...props}): JSX.Element => {

  const [form] = useForm()

  const submitForm = (value: BookingFormFieldProps) => {
    const start = moment(value.time[0].format('YYYY-MM-DDTHH:mm:ss[Z]'))
    const end = moment(value.time[1].format('YYYY-MM-DDTHH:mm:ss[Z]'))
    const payload = {
      applicationId: props.candidate,
      date: value.date,
      start: start,
      end: end,
      reviewerId: value.reviewer
    }

    postBooking(payload).then(res => {
      if (res)
        alert("Ok");
    })
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