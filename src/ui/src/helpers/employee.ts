import { v4 } from "uuid"
import { ListUserProps } from "../apis/employee"

export interface EmployeeViewProps {
  key: string
  id: string
  name: string
  role: string
  department: string
  position: string
  level: string
}

export const convertEmployeeToView = (source: ListUserProps): EmployeeViewProps => {
  return { ...source, ['key']: v4()}
}