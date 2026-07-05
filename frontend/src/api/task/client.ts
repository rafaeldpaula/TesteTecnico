// src/api/client.ts — wrapper único sobre o fetch

// Liga/desliga o envio do token de auth.
// Deixe `false` enquanto a rota de auth não existe; vire para `true` quando ela estiver pronta.
const AUTH_ENABLED = false

async function request<T>(path: string, options: RequestInit = {}): Promise<T> {
  // o JWT da SUA app (só é lido/enviado quando AUTH_ENABLED === true)
  const token = AUTH_ENABLED ? localStorage.getItem('token') : null

  const res = await fetch(path, {
    ...options,
    headers: {
      'Content-Type': 'application/json',
      ...(token ? { Authorization: `Bearer ${token}` } : {}),
      ...options.headers,
    },
  })

  if (!res.ok) {
    throw new Error(`${res.status} ${res.statusText}`)
  }
  // 201/200 com corpo → json; 204 sem corpo → undefined
  return res.status === 204 ? (undefined as T) : await res.json()
}

export const api = {
  get: <T>(path: string) => request<T>(path),
  post: <T>(path: string, body: unknown) =>
    request<T>(path, { method: 'POST', body: JSON.stringify(body) }),
}
