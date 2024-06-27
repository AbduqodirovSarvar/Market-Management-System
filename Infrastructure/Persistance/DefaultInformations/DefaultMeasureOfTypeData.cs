using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DefaultInformations;

public static class DefaultMeasureOfTypeData
{
    public static readonly List<MeasureOfType> DefaultMeasureOfTypes = [
        new MeasureOfType
        {
            NameUz = "Kilogramm",
            NameEn = "Kilogram",
            NameRu = "Килограмм",
            DescriptionUz = "Og'irlik o'lchov birligi",
            DescriptionEn = "Unit of measurement for weight",
            DescriptionRu = "Единица измерения веса"
        },
        new MeasureOfType
        {
            NameUz = "Dona",
            NameEn = "Piece",
            NameRu = "Штука",
            DescriptionUz = "Soni o'lchov birligi",
            DescriptionEn = "Unit of measurement for quantity",
            DescriptionRu = "Единица измерения количества"
        },
        new MeasureOfType
        {
            NameUz = "Blok",
            NameEn = "Block",
            NameRu = "Блок",
            DescriptionUz = "Blok o'lchov birligi",
            DescriptionEn = "Unit of measurement for blocks",
            DescriptionRu = "Единица измерения блоков"
        },
        new MeasureOfType
        {
            NameUz = "Metr",
            NameEn = "Meter",
            NameRu = "Метр",
            DescriptionUz = "Uzunlik o'lchov birligi",
            DescriptionEn = "Unit of measurement for length",
            DescriptionRu = "Единица измерения длины"
        },
        new MeasureOfType
        {
            NameUz = "Kvadrat metr",
            NameEn = "Square meter",
            NameRu = "Квадратный метр",
            DescriptionUz = "Yuz o'lchov birligi",
            DescriptionEn = "Unit of measurement for area",
            DescriptionRu = "Единица измерения площади"
        },
        new MeasureOfType
        {
            NameUz = "Kub metr",
            NameEn = "Cubic meter",
            NameRu = "Кубический метр",
            DescriptionUz = "Hajm o'lchov birligi",
            DescriptionEn = "Unit of measurement for volume",
            DescriptionRu = "Единица измерения объема"
        }
    ];
}
