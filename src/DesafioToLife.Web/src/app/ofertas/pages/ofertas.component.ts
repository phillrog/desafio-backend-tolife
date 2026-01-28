import { Component, OnInit } from '@angular/core';
import { AparelhoDto } from '../models/aparelho-dto.model';
import { AparelhoService } from '../services/aparelho.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-ofertas',
  standalone: false,
  templateUrl: './ofertas.component.html',
  styleUrl: './ofertas.component.scss',
})
export class OfertasComponent implements OnInit {
  aparelhos$!: Observable<AparelhoDto[]>;
  
  constructor(private aparelhoService: AparelhoService) { }

  ngOnInit(): void {
    this.aparelhos$ = this.aparelhoService.getOfertas(1, 100)
  }

}
