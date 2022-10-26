import { Modal, UploadFile } from "antd"
import { useForm } from "antd/es/form/Form"
import { Store } from "antd/lib/form/interface"
import moment from "moment"
import { useEffect } from "react"
import { ApplicationRequestProps, ApplicationResponse, getApplicationDetailFromRecruitment, updateApplicationFromRecruitment } from "../../apis/application"
import { fileUpload } from "../../apis/file"
import ApplicationForm, { ApplicationFormValue } from "./ApplicationForm"

interface ApplicationModalProps {
  visible: boolean
  changeVisible: (state: boolean) => void
  recruitmentId: number
  application: number
}

const convertValueToForm = (source: ApplicationResponse): Store => {
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

const UpdateCandidateModal: React.FC<ApplicationModalProps> = ({...props}): JSX.Element => {
  const [form] = useForm()

  const handleSubmit = async (value: ApplicationFormValue): Promise<void> => {

    const files = form.getFieldValue('attachment') as UploadFile[]
    var url = await fileUpload(files[0].originFileObj as File)

    const data: ApplicationRequestProps = { ...value, ...{ attachment: url, gender: parseInt(value.gender), id: props.application}}
    updateApplicationFromRecruitment(props.recruitmentId, data)
      .then(res => {
        if(res.statusCode === 200){
          alert("Thành công")
        }
      })
  }

  useEffect(() => {
    if(props.application > 0){
      getApplicationDetailFromRecruitment(props.recruitmentId, props.application)
      .then(res => {
        if (res.statusCode === 200){
          const initialFieldValue = convertValueToForm(res.data!)
          form.setFieldsValue(initialFieldValue)
        }
      })
    }
  }, [props.application])

  return (
    <Modal
      title="Cập nhật thông tin ứng viên"
      bodyStyle={{overflowY: 'scroll', maxHeight: '70vh'}}
      open={props.visible}
      onCancel={() => {props.changeVisible(false)}}
      cancelText="Huỷ"
      okText="Lưu"
      onOk={form.submit}>
        <ApplicationForm form={form} onFinish={handleSubmit}/>
    </Modal>
  )
}

export default UpdateCandidateModal;