import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private http: HttpClient) { }

  backend = "http://localhost:5264/"

  post(url: string, obj: any)
  {
    return this.http.post(this.backend + url, obj)
  }
}
