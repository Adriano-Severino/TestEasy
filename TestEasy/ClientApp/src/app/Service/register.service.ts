import { Register } from './../Models/register';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string) { }

  getAll(): Observable<Register[]>
  {
    //buscar no banco os registros
   return this.http.get<Register[]>(this.baseUrl + 'v1/registers')
  }

  getbyId(id: number): Observable<Register>
  {
    //buscar no banco os registro com id
   return this.http.get<Register>(this.baseUrl + `v1/registers/${id}`)
  }

  post(register: Register)
  {
    //registrar um novo registro
    return this.http.post(this.baseUrl + 'v1/registers', register)
  }

  put(register: Register)
  {
    //atualiza um registro
    return this.http.put(this.baseUrl + "v1/registers", register)
  }

  delete(id: number)
  {
    //deleta um registro
    return this.http.delete(this.baseUrl + `v1/registers/${id}`)
  }

}
