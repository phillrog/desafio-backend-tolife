import { PlanoDto } from "./plano-dto.model";

export interface AparelhoDto {
    id: number;
    name: string;
    planos: PlanoDto[];
}