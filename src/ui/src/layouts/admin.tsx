import { Layout, Menu } from "antd"
import { Content, Header } from "antd/lib/layout/layout"
import Sider from "antd/lib/layout/Sider"
import { ItemType } from "antd/lib/menu/hooks/useItems"
import { Link, Route, Routes } from "react-router-dom"
import { ContactsOutlined, ReconciliationOutlined } from "@ant-design/icons"
import './admin.css'
import { adminRoute } from "../routes"
import Recruitment from "../pages/Recruitment"
import { useDispatch } from "react-redux"
import { AppDispatch } from "../store/store"
import { useEffect } from "react"
import { getRoles } from "../apis/role"
import { appendDepartments, appendLevels, appendPositions, appendRoles } from "../store/utilSlice"
import { getDepartments } from "../apis/department"
import { getPositions } from "../apis/position"
import { getLevels } from "../apis/level"
import { appendEmployees, getEmployees } from "../store/employeeSlice"
import { loadUsers } from "../apis/employee"
import { convertEmployeeToView, EmployeeViewProps } from "../helpers/employee"


const createRoute = (): JSX.Element => {
  return (
    <Routes>
      <Route path="*" element={<Recruitment />}></Route>
      {
        adminRoute.map((item, index) => {
          const { element ,path } = item;
          return (
            <Route key={index} path={path} element={element}></Route>
          )
        })
      }
    </Routes>
  )
}

const sidebarMenu: Array<ItemType> = [
  {
    label: <Link to="recruitments">Tuyển dụng</Link>,
    key: 'recruitment',
    icon: <ReconciliationOutlined style={{fontSize: '16px'}}/>
  },
  {
    label: <Link to="candidate">Ứng viên</Link>,
    key: 'candidate',
    icon: <ContactsOutlined style={{fontSize: '16px'}}/>
  },
  {
    label: <Link to="employees">Nhân viên</Link>,
    key: 'employee',
    icon: <ContactsOutlined style={{fontSize: '16px'}}/>
  }
]


const Admin: React.FC = (): JSX.Element => {
  const dispatch = useDispatch<AppDispatch>()

  useEffect(() => {
    getRoles()
      .then(res => {
        if(res.statusCode === 200){
          dispatch(appendRoles(res.data!))
        }
      })

    getDepartments()
      .then(res => {
        if(res.statusCode === 200){
          dispatch(appendDepartments(res.data!))
        }
      })

    getPositions()
      .then(res => {
        if(res.statusCode === 200){
          dispatch(appendPositions(res.data!))
        }
      })

    getLevels()
      .then(res => {
        if(res.statusCode === 200){
          dispatch(appendLevels(res.data!))
        }
      })

    loadUsers()
      .then(res => {
        if(res.statusCode === 200){
          const data = res.data!.map(item => convertEmployeeToView(item))
          dispatch(appendEmployees(data))
        }
      })

  }, [])

  return(
    <Layout>
      <Header className="sticky_header header__container">
        <Link className="home_link" to="">Recruitment System</Link>
      </Header>
      <Layout hasSider>
        <Sider
          theme="dark" 
          collapsible 
          className="sider_fixed"
          style={{width: '20vw'}}>
          <Menu
            theme="dark" 
            items={sidebarMenu}
            mode="vertical"
            defaultSelectedKeys={['recruitment']}
            />
        </Sider>
        <Content className="content">
          <div className="content__container">
          {
            createRoute()
          }
          </div>
        </Content>
      </Layout>
    </Layout>
  )
}

export default Admin