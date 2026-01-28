import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'ofertas',
    loadChildren: () => import('./ofertas/ofertas.module').then(m => m.OfertasModule)
  },
  { path: '', redirectTo: 'ofertas', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
