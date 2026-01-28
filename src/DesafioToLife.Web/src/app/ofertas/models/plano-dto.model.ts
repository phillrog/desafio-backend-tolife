import { LocalidadeDto } from "./localidade-dto.model";
import { ScheduleDto } from "./schedule-dto.model";

export interface PlanoDto {
    id: number;
    type: string;
    name: string;
    phonePrice: number;
    phonePriceOnPlan: number;
    installments: number;
    monthlyFee: number;
    schedule: ScheduleDto;
    localidade: LocalidadeDto;
}