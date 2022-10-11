import { Modal } from "antd"
import { useForm } from "antd/es/form/Form"
import { useState } from "react"
import EmployeeForm from "./EmployeeForm"

interface FormProps {
  visible: boolean
  changeVisible: (state: boolean) => void
}

const NewEmployeeModal: React.FC<FormProps> = ({...props}): JSX.Element => {
  const [form] = useForm()

  const onCancel = (): void => {
    form.resetFields()
    props.changeVisible(false)
  }

  return(
    <Modal
      okText="Thêm"
      cancelText="Huỷ"
      onOk={form.submit}
      onCancel={onCancel}
      open={props.visible}
      title="Thêm nhân viên"
      bodyStyle={{overflowY: 'scroll', maxHeight: '70vh'}}>
      <EmployeeForm form={form} onFinish={() => { }} />
    </Modal>
  )
    
}

export default NewEmployeeModal