import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OfertasComponent } from './ofertas.component';

describe('Ofertas', () => {
  let component: OfertasComponent;
  let fixture: ComponentFixture<OfertasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OfertasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OfertasComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
