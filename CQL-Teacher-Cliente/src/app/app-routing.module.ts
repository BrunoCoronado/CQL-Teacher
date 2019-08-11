import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  //{ path: '',   redirectTo: 'SQL-Teacher/administracion/modoEdicion', pathMatch: 'full' },
  { path: '',   redirectTo: 'SQL-Teacher/editor/avanzado', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
