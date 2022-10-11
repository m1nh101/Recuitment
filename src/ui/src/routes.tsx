import React, { ReactNode } from "react"
import RecruitmentDetail from "./components/Recruitments/RecruitmentDetail"
import Employee from "./pages/Employee"
import Recruitment from "./pages/Recruitment"

interface RouteItem{
  element: ReactNode
  label: string | ReactNode
  path: string
  subRoutes?: Array<RouteItem>
}


export const adminRoute: Array<RouteItem> = [
  {
    label: 'Tuyển dụng',
    path: 'recruitment',
    element: <Recruitment />
  },
  {
    label: 'Ứng viên',
    path: 'candidates',
    element: <React.Fragment></React.Fragment>
  },
  {
    label: '',
    path: '/recruitments/:id',
    element: <RecruitmentDetail />
  },
  {
    label: '',
    path: '/employees',
    element: <Employee />
  }
]