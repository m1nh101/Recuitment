import { Modal, UploadFile } from "antd"
import { useForm } from "antd/es/form/Form"
import { useSelector } from "react-redux"
import { v4 } from "uuid"
import { CandidateRequestProps, CandidateViewType, postCandidateToRecruitment } from "../../apis/candidate"
import { fileUpload } from "../../apis/file"
import { openSuccessNotification } from "../../App"
import { getCurrentRecruitment } from "../../store/recruitmentSlice"
import CandidateForm, { CandidateFormValue } from "./CandidateForm"

interface CandidateModalProp {
  visible: boolean
  changeVisible: (state: boolean) => void
  appendTo: (data: CandidateViewType) => void
}

const CandidateModal: React.FC<CandidateModalProp> = ({...props}): JSX.Element => {
  const [form] = useForm()
  const currentRecruitment: number = useSelector(getCurrentRecruitment)

  const handleSubmit = async (value: CandidateFormValue): Promise<void> => {
    const files = form.getFieldValue('attachment') as UploadFile[]
    var url = await fileUpload(files[0].originFileObj as File)

    const data: CandidateRequestProps = { ...value, ...{ attachment: url, gender: parseInt(value.gender)}}

    postCandidateToRecruitment(currentRecruitment, data)
      .then(res => {
        if (res.statusCode == 200){
          // const viewItem = { ...res.data!, key: v4()}
          // props.appendTo(viewItem)
          // props.changeVisible(false)
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