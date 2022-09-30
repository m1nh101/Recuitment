import React, { ReactNode } from "react"
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
  }
]