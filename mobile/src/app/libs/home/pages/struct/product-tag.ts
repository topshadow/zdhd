import { Product } from './product';
import { SubProduct } from './sub-product';
/**产品标签 */
export class ProductTag {
    productTagId: number;
    products?: Product[]
    /**产品名字 */
    name: string;
    /**创建日期 */
    createTime: Date;
    summary: string;
    /**子产品 */
    subProducts: SubProduct[];
}