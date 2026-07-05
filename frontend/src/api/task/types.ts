// src/api/types.ts
export type Status = 'NotStarted' | 'InProgress' | 'Canceled' | 'Paused' | 'Finished'

export interface TaskItem {
  id: string
  title: string
  description: string
  status: Status
}

export interface CreateTaskRequest {
  title: string
  description: string
}