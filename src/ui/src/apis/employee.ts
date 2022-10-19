import { EmployeeFormProps } from "../components/Employees/EmployeeForm"
import client, { Response } from "./client"

export interface ListUserProps {
  id: string
  name: string
  department: string
  level: string
  role: string
  position: string
}

export interface ListReviewerProps {
  id: string
  name: string
  department: string
}

export interface AddedEmployeeResponse {
  id: string
  name: string
  departmentId: number
  levelId: number
  role: string
  positionId: number
}

export const addUser = async (data: EmployeeFormProps): Promise<Response<AddedEmployeeResponse>> => {
  const response = await client.post('/auth/users', data)
  return response.data
}

export const loadUsers = async (): Promise<Response<Array<ListUserProps>>> => {
  const response = await client.get('/employees')
  return response.data
}

export const getReviewer = async (): Promise<Response<Array<ListReviewerProps>>> => {
  const response = await client.get('/employees/reviewers')
  return response.data
}