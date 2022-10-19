import { Modal } from "antd"
import { useForm } from "antd/es/form/Form"
import { useDispatch, useSelector } from "react-redux"
import { v4 } from "uuid"
import { addUser } from "../../apis/employee"
import { openSuccessNotification } from "../../App"
import { appendEmployee } from "../../store/employeeSlice"
import { AppDispatch } from "../../store/store"
import { getDepartments, getLevel, getPositions, getRoles } from "../../store/utilSlice"
import EmployeeForm, { EmployeeFormProps } from "./EmployeeForm"

interface FormProps {
  visible: boolean
  changeVisible: (state: boolean) => void
}

const NewEmployeeModal: React.FC<FormProps> = ({...props}): JSX.Element => {
  const [form] = useForm()
  const roles = useSelector(getRoles)
  const departments = useSelector(getDepartments)
  const levels = useSelector(getLevel)
  const positions = useSelector(getPositions)
  const dispatch = useDispatch<AppDispatch>()

  const onCancel = (): void => {
    form.resetFields()
    props.changeVisible(false)
  }

  const handleSubmit = (value: EmployeeFormProps): void => {
    addUser(value)
      .then(res => {
        if(res.statusCode === 200){
          const role = roles.find(e => e.id === res.data!.role)
          const department = departments.find(e => e.id === res.data!.departmentId)
          const level = levels.find(e => e.id === res.data!.levelId)
          const position = positions.find(e => e.id === res.data!.positionId)

          dispatch(appendEmployee({
            role: role!.name,
            department: department!.name,
            level: level!.name,
            position: position!.name,
            name: res.data!.name,
            id: res.data!.id,
            key: v4()
          }))

          openSuccessNotification("Thêm nhân viên thành công")
        }
      })
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
      <EmployeeForm form={form} onFinish={handleSubmit} />
    </Modal>
  )
    
}

export default NewEmployeeModal