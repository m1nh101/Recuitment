import { Moment } from "moment"
import client from "./client"

export interface BookingRequest {
  applicationId: number
  date: Moment
  start: Moment
  end: Moment
  reviewerId: string
}

export const postBooking = async (data: BookingRequest): Promise<boolean> => {
  var response = await client.post(`/applications/${data.applicationId}/booking`, data)

  return response.data !== null
}

export const cancelBooking = async (id: number): Promise<boolean> => {
  var response = await client.delete(`/applications/${id}/booking`)

  return response.status === 204
}