import { Modal } from "antd"
import { postRecruitment, RecruitmentRequest } from "../../apis/recruitment";
import { Moment } from "moment";
import { useForm } from "antd/lib/form/Form";
import { Store } from "antd/lib/form/interface";
import RecruitmentForm from "./RecruitmentForm";
import { convertFormDataToObject, convertGeneralRecruitmentDataToViewData } from "../../helpers/recruitment";
import { useDispatch } from "react-redux";
import { addRecruitment } from "../../store/recruitmentSlice";
import { openSuccessNotification } from "../../App";

interface NewRecruitmnetModalProp{
  visible: boolean
  changeVisible: (state: boolean) => void
}

export interface RecruitmentFormValueProps {
  times: [Moment, Moment]
  salary: [number, number]
  experience: [number, number]
  name: string
  content: string
  benifit: string
  quantity: number
  position: number
  department: number
}

const initialFieldValue: Store = {
  ['salary']: [0, 20000000],
  ['experience']: [0, 15]
}

const NewRecruitment: React.FC<NewRecruitmnetModalProp> = ({...props}): JSX.Element => {
  
  const [form] = useForm()
  const dispatch = useDispatch()
  
  const onCancel = (): void => {
    props.changeVisible(false)
  }

  const handleSubmit = (value: RecruitmentFormValueProps): void => {
    const data: RecruitmentRequest = convertFormDataToObject(0, value)
    postRecruitment(data).then(res => {
      if (res.statusCode === 200){
        const viewData = convertGeneralRecruitmentDataToViewData(res.data!)
        dispatch(addRecruitment(viewData))
        onCancel()
        openSuccessNotification("Thêm thành công")
        form.resetFields()
      }
    })
  }

  return (
    <Modal
      open={props.visible}
      title="Tạo tuyển dụng mới"
      cancelText="Huỷ"
      okText="Tạo mới"
      bodyStyle={{overflowY: 'scroll', maxHeight: '70vh'}}
      width={1000}
      onCancel={onCancel}
      onOk={form.submit}
      >
      <RecruitmentForm form={form} initialValues={initialFieldValue} onFinish={handleSubmit}/>
    </Modal>
  )
}

export default NewRecruitment;