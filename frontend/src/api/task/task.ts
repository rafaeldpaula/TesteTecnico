// src/api/tasks.ts — funções específicas do domínio
import { api } from './client'
import type { TaskItem, CreateTaskRequest } from './types'

export const getTasks   = ()                       => api.get<TaskItem[]>('/tasks')
export const getTask    = (id: string)             => api.get<TaskItem>(`/tasks/${id}`)
export const createTask = (data: CreateTaskRequest) => api.post<TaskItem>('/tasks', data)