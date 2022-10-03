import { Modal, UploadFile } from "antd"
import { useForm } from "antd/es/form/Form"
import { useDispatch } from "react-redux"
import { CandidateRequestProps, postCandidateToRecruitment } from "../../apis/candidate"
import { fileUpload } from "../../apis/file"
import { openSuccessNotification } from "../../App"
import { convertCandidateToViewProp } from "../../helpers/candidates"
import { addCandidate } from "../../store/recruitmentSlice"
import { AppDispatch } from "../../store/store"
import CandidateForm, { CandidateFormValue } from "./CandidateForm"

interface CandidateModalProp {
  visible: boolean
  changeVisible: (state: boolean) => void
  recruitmentId: number
}

const CandidateModal: React.FC<CandidateModalProp> = ({...props}): JSX.Element => {
  const [form] = useForm()
  const dispatch = useDispatch<AppDispatch>()

  const handleSubmit = async (value: CandidateFormValue): Promise<void> => {
    const files = form.getFieldValue('attachment') as UploadFile[]
    var url = await fileUpload(files[0].originFileObj as File)

    const data: CandidateRequestProps = { ...value, ...{ attachment: url, gender: parseInt(value.gender)}}

    postCandidateToRecruitment(props.recruitmentId, data)
      .then(res => {
        if (res.statusCode == 200){
          const viewItem = convertCandidateToViewProp(res.data!)
          dispatch(addCandidate(viewItem))
          props.changeVisible(false)
          form.resetFields()
          openSuccessNotification(res.message)
        }
      })
  }

  return (
    <Modal
      title="Thêm ứng viên"
      bodyStyle={{overflowY: 'scroll', maxHeight: '70vh'}}
      open={props.visible}
      onCancel={() => props.changeVisible(false)}
      cancelText="Huỷ"
      okText="Thêm"
      onOk={form.submit}>
        <CandidateForm form={form} onFinish={handleSubmit}/>
    </Modal>
  )
}

export default CandidateModal;