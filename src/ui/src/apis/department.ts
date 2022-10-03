import client, { Response } from "./client"

export interface DepartmentProp{
  id: number
  name: string
  location: string
}

type GetDepartmentResponse = Response<Array<DepartmentProp>>

export const getDepartments = async (): Promise<GetDepartmentResponse> => {
  const response = await client.get<GetDepartmentResponse>('/departments')
  return response.data
}