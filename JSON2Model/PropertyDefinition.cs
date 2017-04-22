namespace JSON2Model
{
    public class PropertyDefinition
    {
        public JsonType PropertyType { get; set; }

        /// <summary>
        /// 当<see cref="PropertyType"/>等于<see cref="JsonType.Class"/>时
        /// 此为类型名称
        /// </summary>
        public string ClassName { get; set; }

        public string Name { get; set; }
        
        public bool IsArray { get; set; }
    }
}
