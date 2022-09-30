import { useState } from "react";
import Admin from "./layouts/admin";
import 'antd/dist/antd.css'

const App: React.FC = (): JSX.Element => {
  const [admin, setAdmin] = useState<boolean>(true)

  if(admin){
    return <Admin />
  }

  return <></>
}

export default App;