import Image from "next/image";
import styles from "./page.module.css";
import 'bootstrap/dist/css/bootstrap.css'
import Product from "./components/products/product";

export default function Home() {
  return (
    <div className={styles.page}>
        <Product/>
    </div>
  );
}
