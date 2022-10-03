import { Modal, UploadFile } from "antd"
import { useForm } from "antd/es/form/Form"
import { Store } from "antd/lib/form/interface"
import moment from "moment"
import { useEffect } from "react"
import { CandidateRequestProps, CandidateResponse, getCandidateDetailFromRecruitment, updateCandidateFromRecruitment } from "../../apis/candidate"
import { fileUpload } from "../../apis/file"
import CandidateForm, { CandidateFormValue } from "./CandidateForm"

interface CandidateModalProp {
  visible: boolean
  changeVisible: (state: boolean) => void
  recruitmentId: number
  candidateId: number
}

const convertValueToForm = (source: CandidateResponse): Store => {
  return {
    ['name']: source.name,
    ['birthday']: moment(source.birthday),
    ['gender']: source.gender.toString(),
    ['qualification']: source.qualification,
    ['email']: source.email,
    ['phone']: source.phone,
    ['address']: source.address,
    ['note']: source.note
  }
}

const UpdateCandidateModal: React.FC<CandidateModalProp> = ({...props}): JSX.Element => {
  const [form] = useForm()

  const handleSubmit = async (value: CandidateFormValue): Promise<void> => {

    const files = form.getFieldValue('attachment') as UploadFile[]
    var url = await fileUpload(files[0].originFileObj as File)

    const data: CandidateRequestProps = { ...value, ...{ attachment: url, gender: parseInt(value.gender), id: props.candidateId}}
    updateCandidateFromRecruitment(props.recruitmentId, data)
      .then(res => {
        if(res.statusCode === 200){
          alert("Thành công")
        }
      })
  }

  useEffect(() => {
    if(props.candidateId > 0){
      getCandidateDetailFromRecruitment(props.recruitmentId, props.candidateId)
      .then(res => {
        if (res.statusCode === 200){
          const initialFieldValue = convertValueToForm(res.data!)
          form.setFieldsValue(initialFieldValue)
        }
      })
    }
  }, [props.candidateId])

  return (
    <Modal
      title="Cập nhật thông tin ứng viên"
      bodyStyle={{overflowY: 'scroll', maxHeight: '70vh'}}
      open={props.visible}
      onCancel={() => {props.changeVisible(false)}}
      cancelText="Huỷ"
      okText="Lưu"
      onOk={form.submit}>
        <CandidateForm form={form} onFinish={handleSubmit}/>
    </Modal>
  )
}

export default UpdateCandidateModal;