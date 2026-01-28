import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AparelhoDto } from '../models/aparelho-dto.model';

@Injectable({ providedIn: 'root' })
export class AparelhoService {
    
  private readonly API_URL = 'https://localhost:7121/api/Aparelhos/ofertas';

  constructor(private http: HttpClient) {}

  getOfertas(page: number = 1, pageSize: number = 100): Observable<AparelhoDto[]> {
    const params = new HttpParams()
      .set('page', page.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<AparelhoDto[]>(this.API_URL, { params });
  }
}