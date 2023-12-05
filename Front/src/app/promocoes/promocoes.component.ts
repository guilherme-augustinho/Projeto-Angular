import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavComponent } from '../nav/nav.component';

@Component({
  selector: 'app-promocoes',
  standalone: true,
  imports: [CommonModule, NavComponent],
  templateUrl: './promocoes.component.html',
  styleUrl: './promocoes.component.css'
})
export class PromocoesComponent {

}
