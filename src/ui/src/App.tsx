import { useEffect, useState } from "react";
import Admin from "./layouts/admin";
import 'antd/dist/antd.css'
import { useDispatch } from "react-redux";
import { getRecruitments } from "./apis/recruitment";
import { convertGeneralRecruitmentDataToViewData } from "./helpers/recruitment";
import { loadRecruitment } from "./store/recruitmentSlice";
import notification from "antd/lib/notification";

export const openSuccessNotification = (message: string) => {
  notification['success']({
    message: message
  });
};

const App: React.FC = (): JSX.Element => {
  const [admin, setAdmin] = useState<boolean>(true)

  const dispatch = useDispatch()

  useEffect(() => {
    getRecruitments().then(res => {
      const sources = res.data?.map(item => convertGeneralRecruitmentDataToViewData(item))
      dispatch(loadRecruitment(sources))
    })
  }, [])


  if(admin){
    return <Admin />
  }

  return <></>
}

export default App;