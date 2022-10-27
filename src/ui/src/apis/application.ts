import { Moment } from "moment"
import client, { Response } from "./client"


export enum Status {
  BookedInterview = 4,
  CanceledApply = 5,
  WaitBookingInterview = 6
}

export interface ApplicationViewType extends ApplicationInRecruitmentProps
{ key: string }

export interface GeneralApplicationProps {
  id?: number
  name: string
  gender: number
  birthday: Moment
  email: string
  phone: string
  address: string
}

export interface ApplicationInRecruitmentProps extends GeneralApplicationProps {
  status: Status
}

export interface ApplicationRequestProps extends GeneralApplicationProps {
  qualification: string
  attachment: string
  gender: number
  note: string
  recruitmentId?: number
}

export type ApplicationResponse = ApplicationRequestProps

export const postApplicationToRecruitment = async (recruitmentId: number, data: ApplicationRequestProps): Promise<Response<ApplicationResponse>> => {
  const response = await client.post(`/recruitments/${recruitmentId}/applications`, data)
  return response.data
}

export const deleteApplicationFromRecruitment = async (recruitmentId: number, application: number): Promise<boolean> => {
  const response = await client.delete(`/recruitments/${recruitmentId}/applications/${application}`)

  return response.status === 200
}

export const getApplicationDetailFromRecruitment = async (recruitmentId: number, applicationId: number): Promise<Response<ApplicationResponse>> => {
  const response = await client.get(`/recruitments/${recruitmentId}/applications/${applicationId}`)
  return response.data
}

export const updateApplicationFromRecruitment = async (recruitmentId: number, data: ApplicationRequestProps): Promise<Response<ApplicationResponse>> => {
  const response = await client.patch(`/recruitments/${recruitmentId}/Applications/${data.id}`, data)
  return response.data
}