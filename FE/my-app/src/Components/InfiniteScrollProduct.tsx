import {
    useInfiniteQuery,
    QueryFunctionContext,
  } from '@tanstack/react-query'
  import { useEffect, useRef } from 'react'
  
  type ProductModel = {
    id: number
    title: string
    price: number
  }
  
  type PageResponse = {
    data: ProductModel[]
    nextPage: number
    hasMore: boolean
  }
  
  const fetchProductsByPage = async (
    ctx: QueryFunctionContext
  ): Promise<PageResponse> => {
    const pageParam = (ctx.pageParam ?? 1) as number
    const limit = 5
    const skip = (pageParam - 1) * limit
  
    const response = await fetch(
      `https://dummyjson.com/products?limit=${limit}&skip=${skip}`
    )
    const json = await response.json()
  
    return {
      data: json.products,
      nextPage: pageParam + 1,
      hasMore: skip + limit < json.total,
    }
  }
  
  const InfiniteScrollProduct = () => {
    const containerRef = useRef<HTMLDivElement | null>(null)
    const sentinelRef = useRef<HTMLDivElement | null>(null)
  
    const {
      data,
      fetchNextPage,
      hasNextPage,
      isFetchingNextPage,
      status,
      error,
    } = useInfiniteQuery<PageResponse, Error>({
      queryKey: ['products'],
      queryFn: fetchProductsByPage,
      getNextPageParam: (lastPage) =>
        lastPage.hasMore ? lastPage.nextPage : undefined,
      initialPageParam: 1,
    })
  
    useEffect(() => {
      if (!sentinelRef.current || !containerRef.current || !hasNextPage) return
  
      const observer = new IntersectionObserver(
        (entries) => {
          if (entries[0].isIntersecting) {
            fetchNextPage()
          }
        },
        {
          root: containerRef.current, // 🔥 watch inside the scroll container
          threshold: 1.0,
        }
      )
  
      observer.observe(sentinelRef.current)
  
      return () => {
        if (sentinelRef.current) observer.unobserve(sentinelRef.current)
      }
    }, [fetchNextPage, hasNextPage])
  
    if (status === 'pending') return <p>Loading...</p>
    if (status === 'error') return <p>Error: {error.message}</p>
  
    return (
      <div
        ref={containerRef}
        style={{
            width:'1200px',
          height: '400px',
          overflowY: 'auto',
          border: '1px solid gray',
          padding: '10px',
        }}
      >
        {data?.pages.map((page, i) => (
          <div key={i}>
            {page.data.map((product) => (
              <div
                key={product.id}
                style={{
                  border: '1px solid #ccc',
                  margin: '8px',
                  padding: '8px',
                }}
              >
                <h4>{product.title}</h4>
                <p>Price: ${product.price}</p>
              </div>
            ))}
          </div>
        ))}
  
        {/* Sentinel element to observe for triggering next page */}
        <div ref={sentinelRef} style={{ height: 100 }} />
  
        {isFetchingNextPage && <p>Loading more...</p>}
      </div>
    )
  }
  
  export default InfiniteScrollProduct
  