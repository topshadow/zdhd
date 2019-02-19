import { SubProduct } from './sub-product';
import { ProductImage } from './product-image';

/**产品表 */
export class Product {
    productId: number;
    /**产品名字 */
    name: string;
    subProducts: SubProduct[];
    summary: string;
    productImages: ProductImage[];
}