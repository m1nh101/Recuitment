import client, { Response } from "./client"

export interface LevelProps {
  id: number
  name: string
}

export interface DepartmentProps {
  id: number
  name: string
  location: string
}

export interface PositionProps {
  id: number
  name: string
}

type GetLevelProps = Array<LevelProps>
type GetPositionProps = Array<PositionProps>
type GetDepartmentProps = Array<DepartmentProps>

export const getLevels = async (): Promise<GetLevelProps> => {
  var response = await client.get('/utils/levels')
  return response.data
}

export const getPositions = async (): Promise<GetPositionProps> => {
  const response = await client.get('/utils/positions')
  return response.data
}

export const getDepartments = async (): Promise<GetDepartmentProps> => {
  const response = await client.get('/utils/departments')
  return response.data
}