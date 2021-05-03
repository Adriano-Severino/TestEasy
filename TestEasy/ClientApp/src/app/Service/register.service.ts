import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Register } from '../Models/register';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string) { }

  getAll(): Observable<Register[]>
  {
   return this.http.get<Register[]>(this.baseUrl + 'v1/registers')
  }

  getbyId(id: number): Observable<Register>
  {
   return this.http.get<Register>(this.baseUrl + "v1/registers/${id}")
  }
}
