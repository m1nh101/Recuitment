import { Button } from "antd"
import { useState } from "react"
import ListEmployee from "../components/Employees/ListEmployee"
import NewEmployeeModal from "../components/Employees/NewEmployeeModal"

const Employee: React.FC = (): JSX.Element => {
  const [visible, setVisible] = useState<boolean>(false)

  const openModal = (): void => {
    setVisible(true)
  }
  
  return (
    <div>
      <div className="p-1 flex-end">
        <Button onClick={openModal} type="primary">Thêm mới tuyển dụng</Button>
      </div>
      <div className="p-1">
        <ListEmployee />
      </div>
      <NewEmployeeModal visible={visible} changeVisible={setVisible}/>
    </div>
  )
}

export default Employee