import { Component, OnInit } from '@angular/core';
import { AparelhoDto } from '../models/aparelho-dto.model';
import { AparelhoService } from '../services/aparelho.service';

@Component({
  selector: 'app-ofertas',
  standalone: false,
  templateUrl: './ofertas.component.html',
  styleUrl: './ofertas.component.scss',
})
export class OfertasComponent implements OnInit {
  aparelhos: AparelhoDto[] = [];
  
  constructor(private aparelhoService: AparelhoService) { }

  ngOnInit(): void {
    this.aparelhoService.getOfertas(1, 100).subscribe({
      next: (data) => this.aparelhos = data,
      error: (err) => console.error('Erro ao carregar ofertas', err)
    });
  }

}
