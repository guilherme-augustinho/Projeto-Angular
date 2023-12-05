import { Injectable } from '@angular/core';
import { ClientData } from '../DTO/client-data';
import { ApiClientService } from './api-client.service';


@Injectable({
  providedIn: 'root'
})
export class ClientServiceService {
  constructor(private http: ApiClientService) { }

  register(data: ClientData)
  {
    this.http.post("user/register", data)
      .subscribe(r => console.log(r))
  }

  login(data: ClientData)
  {
    this.http.post('user/login', data)
      .subscribe(r => console.log(r))
  }
}
