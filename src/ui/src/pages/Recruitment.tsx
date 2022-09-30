import { Button } from "antd";
import { useState } from "react";
import NewRecruitment from "../components/Recruitments/Form/NewRecruitment";

const Recruitment: React.FC = (): JSX.Element => {
  const [visible, setVisible] = useState<boolean>(false)

  const openModal = (): void => {
    setVisible(true)
  }


  return (
    <div>
      <div className="p-1 flex-end">
        <Button onClick={openModal} type="primary">Thêm mới tuyển dụng</Button>
      </div>
      <NewRecruitment visible={visible} />
    </div>
  )
}

export default Recruitment;